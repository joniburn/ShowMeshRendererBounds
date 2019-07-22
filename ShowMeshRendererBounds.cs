/*
 * ShowMeshRendererBounds.cs
 *
 * Copyright (c) 2019 joniburn@gmail.com
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using UnityEngine;

/*
 * MeshRendererのBoundsをエディタ画面上に表示するコンポーネントです。
 *
 * MeshRenderer(MeshFilter)をアタッチしてあるGameObjectに本コンポーネントを
 * アタッチすると、Sceneウィンドウ上の該当オブジェクトに黄色いワイヤーフレームで
 * Boundsが表示されます。
 */
[ExecuteInEditMode]
public class ShowMeshRendererBounds : MonoBehaviour {

    Bounds meshBounds;

    void OnEnable () {
        Mesh mesh = this.GetComponent<MeshFilter>().sharedMesh;
        this.meshBounds = new Bounds(mesh.bounds.center, mesh.bounds.size);
    }

    void OnDisable () {
        this.meshBounds = new Bounds();
    }

    void OnDrawGizmos () {
        // オブジェクトの中心位置、Boundsの中心位置、Boundsの回転からMatrixを作成
        Matrix4x4 trans = Matrix4x4.TRS(
            this.transform.position,
            this.transform.rotation,
            this.transform.lossyScale
        );

        // Gizmoを描画
        Gizmos.color = Color.yellow;
        Gizmos.matrix = trans;
        Gizmos.DrawWireCube(this.meshBounds.center, this.meshBounds.size);
    }

}
